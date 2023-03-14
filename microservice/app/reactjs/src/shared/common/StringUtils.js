/* eslint-disable no-useless-escape */
import * as enums from "../../shared/constants/enum/constants";
export default class StringUtils {
  static isNullOrEmpty(value) {
    if (value == "undefined" || value == null || value.length === 0) {
      return true;
    }
    return false;
  }
  static equalsIgnoreCase(value1, value2) {
    value1 = value1 == null ? "" : value1;
    value2 = value2 == null ? "" : value2;
    return value1.toLocaleLowerCase() === value2.toLocaleLowerCase();
  }

  static containsObject(obj, list) {
    if (list == null) {
      return false;
    }
    return list.some(function (elem) {
      return elem === obj;
    });
  }

  static containString(value, containStr) {
    if (this.isNullOrEmpty(value)) {
      return false;
    }
    if (
      (value + "")
        .toLocaleLowerCase()
        .indexOf((containStr + "").toLocaleLowerCase()) != -1
    ) {
      return true;
    }
    return false;
  }

  static trimText(value) {
    if (value != null) {
      return (value + "").trim();
    }
    return value;
  }

  static upperCaseFirstKeyTexts(key) {
    return key
      ? key
        .split(" ")
        .map(
          (key) => key.charAt(0).toUpperCase() + key.slice(1).toLowerCase()
        )
        .join(" ")
      : "";
  }

  static list_to_treeNew(list) {
    if (list) {
      var map = {},
        node,
        roots = [],
        i;
      for (i = 0; i < list.length; i += 1) {
        map[list[i].Id] = i; // initialize the map
        list[i].children = []; // initialize the children
      }

      for (i = 0; i < list.length; i += 1) {
        node = list[i];
        if (node.Parentid !== null) {
          // if you have dangling branches check that map[node.parentId] exists
          list[map[node.Parentid]].children.push(node);
        } else {
          roots.push(node);
        }
      }
      return roots;
    }
    return [];
  }

  static flatten(array, type) {
    const arr = [];
    (function recurrence(array) {
      array.forEach(item => {
        if (type === enums.DropDownType.WorkArea) {
          var object = {
            Name: item.Name,
            Id: item.Id,
            Parentid: item.Parentid,
            Code: item.Code,
            Status: item.Status,
            NameWorker: item.NameWorker,
            Note: item.Note,
            Level: item.Level,
            isClick: false,
          };
          if (object.Level == 0) {
            object.isShow = true;
          }
          arr.push(object);
        }
        if (item.children) {
          recurrence(item.children);
        }
      });
    })(array);
    return arr;
  }
  static substring(value, length = 40) {
    if (value) {
      if (value.length <= length) {
        return value;
      }
      // value lớn hơn length cho phép
      return value.substring(0, length) + "...";
    }
    return "";
  }
  static dateConvert(dateValue) {
    var date = new Date(dateValue),
      mnth = ("0" + (date.getMonth() + 1)).slice(-2),
      day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join("-");
  }

  static dateConvertGetTimezoneOffset(date) {
    if (typeof date?.getMonth === 'function') {
      // var today = new Date();
      // here is the default behavior
      // console.log(date.toJSON());
      // here is the hack fix
      date.setHours(date.getHours() + (date.getTimezoneOffset() / -60));
      // and the right time
      // console.log(date.toJSON());
      return date.toJSON();
    }
    return date;
  }
  static removeAccents(str) {
    str = str.toLowerCase().trim();
    //     We can also use this instead of from line 11 to line 17
    //     str = str.replace(/\u00E0|\u00E1|\u1EA1|\u1EA3|\u00E3|\u00E2|\u1EA7|\u1EA5|\u1EAD|\u1EA9|\u1EAB|\u0103|\u1EB1|\u1EAF|\u1EB7|\u1EB3|\u1EB5/g, "a");
    //     str = str.replace(/\u00E8|\u00E9|\u1EB9|\u1EBB|\u1EBD|\u00EA|\u1EC1|\u1EBF|\u1EC7|\u1EC3|\u1EC5/g, "e");
    //     str = str.replace(/\u00EC|\u00ED|\u1ECB|\u1EC9|\u0129/g, "i");
    //     str = str.replace(/\u00F2|\u00F3|\u1ECD|\u1ECF|\u00F5|\u00F4|\u1ED3|\u1ED1|\u1ED9|\u1ED5|\u1ED7|\u01A1|\u1EDD|\u1EDB|\u1EE3|\u1EDF|\u1EE1/g, "o");
    //     str = str.replace(/\u00F9|\u00FA|\u1EE5|\u1EE7|\u0169|\u01B0|\u1EEB|\u1EE9|\u1EF1|\u1EED|\u1EEF/g, "u");
    //     str = str.replace(/\u1EF3|\u00FD|\u1EF5|\u1EF7|\u1EF9/g, "y");
    //     str = str.replace(/\u0111/g, "d");
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    // Some system encode vietnamese combining accent as individual utf-8 characters
    str = str.replace(/\u0300|\u0301|\u0303|\u0309|\u0323/g, ""); // Huyền sắc hỏi ngã nặng 
    str = str.replace(/\u02C6|\u0306|\u031B/g, ""); // Â, Ê, Ă, Ơ, Ư
    return str;
  }
  static toSeoUrl(url) {
    return url.toString()               // Convert to string
      .normalize('NFD')               // Change diacritics
      .replace(/[\u0300-\u036f]/g, '') // Remove illegal characters
      .replace(/\s+/g, '-')            // Change whitespace to dashes
      .toLowerCase()                  // Change to lowercase
      .replace(/&/g, '-and-')          // Replace ampersand
      // eslint-disable-next-line no-useless-escape
      .replace(/[^a-z0-9\-]/g, '')     // Remove anything that is not a letter, number or dash
      .replace(/-+/g, '-')             // Remove duplicate dashes
      .replace(/^-*/, '')              // Remove starting dashes
      .replace(/-*$/, '');             // Remove trailing dashes
  }
}
export const _formatString = (str, c = ' ', isKeepCase = false) => {
  if (!isKeepCase) {
    str = str.toLowerCase();
  }
  str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
  str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
  str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
  str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
  str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
  str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
  str = str.replace(/đ/g, "d");

  str = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
  str = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
  str = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, "I");
  str = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, "O");
  str = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, "U");
  str = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, "Y");
  str = str.replace(/Đ/g, "D");

  str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\&lt;|\&gt;|\?|\/|,|\.|\:|\;|\'| |\"|\&amp;|\#|\[|\]|~|$|_/g, c);

  str = str.replace(`/${c}+${c}/g`, c);
  str = str.replace(`/^${c}+|${c}+$/g`, "");
  return str;
}