import axios from "axios";
import { closeLoading } from "./LoadingAction";
import toastJs from "./toastJs";
import { mgCookiesHelper } from '../utils/MESCookiesHelper';
import {
  loadUserFromStorage,
} from "src/shared/oidc-client-base/userService";

var CommonBase = {
  get(api, data, onSuccess, onError) {
    axios
      .get(api, {
        params: data,
      })
      .then(function (response) {
        if (onSuccess) onSuccess(response.data);
      })
      .catch(function (error) {
        if (onError) onError(error);
      });
  },
  post(api, data, onSuccess, onError) {
    axios
      .post(api, data, { "Content-Type": "application/json" })
      .then(function (response) {
        if (onSuccess) onSuccess(response.data);
      })
      .catch(function (error) {
        if (onError) onError(error);
      });
  },
  async postFile(api, data, onSuccess, onError) {
    let formData = new FormData();
    formData.append("files", data.files[0]);
    formData.append("typeFile", data.typeFile);
    axios
      .post(api, formData, { "Content-Type": "multipart/form-data" })
      .then(function (response) {
        if (onSuccess) onSuccess(response.data);
      })
      .catch(function (error) {
        if (onError) onError(error);
      });
  },
  async getAsync(api, data) {
    try {
      var result = await axios.get(
        api,
        {
          params: data,
        },
        { "Content-Type": "application/json" }
      );
      return result.data;
    } catch (e) {
      if (e.response.status == 401) {
        // toastJs.error("401");
        await loadUserFromStorage();
      } else {
        let mesError = e?.response?.data?.message
          ? e?.response?.data?.message
          : "Lỗi hệ thống";
        toastJs.error(mesError);
        closeLoading();
      }
      return e;
    }
  },

  async postAsync(api, data) {
    try {
      let result = await axios.post(api, data, {
        "Content-Type": "application/json",
      });
      return result.data;
    } catch (e) {
      if (e?.response?.status == 401) {
        // toastJs.error("401");
        await loadUserFromStorage();
      } else {
        let mesError = e?.response?.data?.message
          ? e?.response?.data?.message
          : "Lỗi hệ thống";
        toastJs.error(mesError);
        closeLoading();
      }
      // eslint-disable-next-line no-undef
      return e;
    }
  },
  setAuthHeader(token) {
    axios.defaults.headers.common["Authorization"] = token
      ? "Bearer " + token
      : "";
  },
  setLanguaueHeader(lang) {
    mgCookiesHelper.set("language", lang, 30);
    axios.defaults.headers.common["language"] = lang;
  },
  async postAsyncExportExcel(api, data) {
    try {
      let result = await axios.post(api, data, {
        "Content-Type": "application/json",
        "responseType": "blob",
      });
      return {
        data: result.data,
        isSuccess: true,
      };
    } catch (e) {
      if (e.response.status == 401) {
        // toastJs.error("401");
        await loadUserFromStorage();
      } else {
        let mesError = e?.response?.data?.message
          ? e?.response?.data?.message
          : "lỗi";
        toastJs.error(mesError);
        closeLoading();
      }
      // eslint-disable-next-line no-undef
      return {
        data: "",
        isSuccess: false,
      };
    }
  },
};

export default CommonBase;
