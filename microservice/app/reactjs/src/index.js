/* eslint-disable */
import { createRoot } from 'react-dom/client';
import { I18nextProvider } from 'react-i18next';
import { Provider } from 'react-redux';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { applyMiddleware, combineReducers, legacy_createStore as createStore } from 'redux';
import createSagaMiddleware from 'redux-saga';
import App from './App';
import './i18n';
import rootReducer from './redux-saga/reducers/rootReducers/HomeRootReducers';
import rootSaga from './redux-saga/sagas/rootSagas/HomeRootSaga';
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const sagaMiddleware = createSagaMiddleware();
const rootReducerHome = combineReducers({
  ...rootReducer
});
const store = createStore(rootReducerHome, applyMiddleware(sagaMiddleware));
sagaMiddleware.run(rootSaga);
const root = createRoot(rootElement);
root.render(
  <I18nextProvider>
        <Provider
         store={store}
         >
          <App />
        </Provider>
      <ToastContainer />
  </I18nextProvider>
);

