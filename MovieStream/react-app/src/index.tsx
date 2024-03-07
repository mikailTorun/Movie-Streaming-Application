import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';


import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import Login from './pages/authontication/Login';
import SignUp from './pages/authontication/SignUp';
import Dashboard from './components/dashboard';
import store from './stores/store';
import { Provider } from 'react-redux';

// routes: [
//   {
//       path: '/dashboard',
//       component: AppLayout,
//       meta : {
//           authRequired : true
//       },
//       children: [
//           {
//               path: '/dashboard',
//               name: 'dashboard',
//               component: () => import('@/views/Dashboard.vue')
//           },
//           {
//               path: '/uikit/formlayout',
//               name: 'formlayout',
//               component: () => import('@/views/uikit/FormLayout.vue')
//           },
//           {
//               path: '/uikit/input',
//               name: 'input',
//               component: () => import('@/views/uikit/Input.vue')
//           },
//           {
//               path: '/uikit/floatlabel',
//               name: 'floatlabel',
//               component: () => import('@/views/uikit/FloatLabel.vue')
//           },
//           {
//               path: '/uikit/invalidstate',
//               name: 'invalidstate',
//               component: () => import('@/views/uikit/InvalidState.vue')
//           },
//           {
//               path: '/uikit/button',
//               name: 'button',
//               component: () => import('@/views/uikit/Button.vue')
//           },
//           {
//               path: '/uikit/table',
//               name: 'table',
//               component: () => import('@/views/uikit/Table.vue')
//           },
//           {
//               path: '/uikit/list',
//               name: 'list',
//               component: () => import('@/views/uikit/List.vue')
//           },
//           {
//               path: '/uikit/tree',
//               name: 'tree',
//               component: () => import('@/views/uikit/Tree.vue')
//           },
//           {
//               path: '/uikit/panel',
//               name: 'panel',
//               component: () => import('@/views/uikit/Panels.vue')
//           },

//           {
//               path: '/uikit/overlay',
//               name: 'overlay',
//               component: () => import('@/views/uikit/Overlay.vue')
//           },
//           {
//               path: '/uikit/media',
//               name: 'media',
//               component: () => import('@/views/uikit/Media.vue')
//           },
//           {
//               path: '/uikit/menu',
//               component: () => import('@/views/uikit/Menu.vue'),
//               children: [
//                   {
//                       path: '/uikit/menu',
//                       component: () => import('@/views/uikit/menu/PersonalDemo.vue')
//                   },
//                   {
//                       path: '/uikit/menu/seat',
//                       component: () => import('@/views/uikit/menu/SeatDemo.vue')
//                   },
//                   {
//                       path: '/uikit/menu/payment',
//                       component: () => import('@/views/uikit/menu/PaymentDemo.vue')
//                   },
//                   {
//                       path: '/uikit/menu/confirmation',
//                       component: () => import('@/views/uikit/menu/ConfirmationDemo.vue')
//                   }
//               ]
//           },
//           {
//               path: '/uikit/message',
//               name: 'message',
//               component: () => import('@/views/uikit/Messages.vue')
//           },
//           {
//               path: '/uikit/file',
//               name: 'file',
//               component: () => import('@/views/uikit/File.vue')
//           },
//           {
//               path: '/uikit/charts',
//               name: 'charts',
//               component: () => import('@/views/uikit/Chart.vue')
//           },
//           {
//               path: '/uikit/misc',
//               name: 'misc',
//               component: () => import('@/views/uikit/Misc.vue')
//           },
//           {
//               path: '/blocks',
//               name: 'blocks',
//               component: () => import('@/views/utilities/Blocks.vue')
//           },
//           {
//               path: '/utilities/icons',
//               name: 'icons',
//               component: () => import('@/views/utilities/Icons.vue')
//           },
//           {
//               path: '/pages/timeline',
//               name: 'timeline',
//               component: () => import('@/views/pages/Timeline.vue')
//           },
//           {
//               path: '/pages/empty',
//               name: 'empty',
//               component: () => import('@/views/pages/Empty.vue')
//           },
//           {
//               path: '/pages/product',
//               name: 'product',
//               component: () => import('@/views/pages/Product.vue'),
//               meta : {
//                   authRequired : true
//               }
//           },
//           {
//               path: '/pages/crud',
//               name: 'crud',
//               component: () => import('@/views/pages/Crud.vue')
//           },
//           {
//               path: '/documentation',
//               name: 'documentation',
//               component: () => import('@/views/utilities/Documentation.vue')
//           }
//       ]
//   },
//   {
//       path: '/',
//       name: 'login',
//       component: () => import('@/views/pages/auth/Login.vue')
//   },
//   {
//       path: '/account/register',
//       name: 'register',
//       component: () => import('@/views/pages/auth/Register.vue')
//   },
//   {
//       path: '/landing',
//       name: 'landing',
//       component: () => import('@/views/pages/Landing.vue')
//   },
//   {
//       path: '/pages/notfound',
//       name: 'notfound',
//       component: () => import('@/views/pages/NotFound.vue')
//   },
//   { path: '/:pathMatch(.*)*', component: () => import('@/views/pages/NotFound.vue') },
//   {
//       path: '/auth/access',
//       name: 'accessDenied',
//       component: () => import('@/views/pages/auth/Access.vue')
//   },
//   {
//       path: '/auth/error',
//       name: 'error',
//       component: () => import('@/views/pages/auth/Error.vue')
//   }
// ]
const router = createBrowserRouter([
  {
    path: "/",
    element: <Login/>,
  },
  {
    path: "/signup",
    element:<SignUp/>,
  },
  {
    path: "/dashboard",
    element:<Dashboard/>,
    // children: [
    //   {
    //     path:"/AllMovie"
    //   },
    //   {
    //     path:"/Marked"
    //   }
    // ]
  }
]);
const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <Provider store={store}>
    <React.StrictMode>
      <RouterProvider router={router} />
    </React.StrictMode>
  </Provider>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
