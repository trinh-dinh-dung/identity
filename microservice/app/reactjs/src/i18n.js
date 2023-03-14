import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';
import {translationEN} from './shared/constants/locales/translationEN';
import {translationVI} from './shared/constants/locales/translationVI';

const resources = {
    en: {translation: translationEN},
    vi: {translation: translationVI}
};

i18n.use(initReactI18next)
    .init({
        resources,
        // fallbackLng: 'vi',
        lng: 'en', // check get cookies => find langue =>['vi','en'....] = cookie, cookie == null or undefined default 'vi'
        // debug: true,
        interpolation: {
            escapeValue: true
        }
    });

export default i18n;