
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue') },
      { path: 'add', 
      component: () => import('pages/add.vue') },
      {path: 'Login', 
      component: () => import('pages/Login.vue')},
      {path: 'Logout', 
      component: () => import('pages/Logout.vue')},
    ],
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes;
