<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="leftDrawerOpen = !leftDrawerOpen"
        />

        <q-toolbar-title>
          <img src="https://cdn-icons-png.flaticon.com/32/2674/2674486.png" />
        </q-toolbar-title>

        <!-- <div>Quasar v{{ $q.version }}</div> -->
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
      content-class="bg-primary"
    >
      <q-list>
        <q-item-label header> ข้อมูลสินค้า </q-item-label>
        <q-item clickable v-ripple @click="ToIndex()">
          <q-item-section avatar>
            <q-avatar rounded>
              <img
                src="https://cdn-icons-png.flaticon.com/512/869/869636.png"
              />
            </q-avatar>
          </q-item-section>
          <q-item-section class="font">หน้าหลัก</q-item-section>
        </q-item>

        <q-item clickable v-ripple @click="ToAdd()">
          <q-item-section avatar>
            <q-avatar rounded>
              <img
                src="https://img.icons8.com/cotton/512/plus--v2.png"
              />
            </q-avatar>
          </q-item-section>
          <q-item-section class="font">เพิ่มข้อมูลสินค้า</q-item-section>
        </q-item>

        <q-item clickable v-ripple @click="Login()">
          <q-item-section avatar>
            <q-avatar rounded>
              <img
                src="https://img.icons8.com/external-flaticons-flat-flat-icons/512/external-login-web-development-flaticons-flat-flat-icons.png"
              />
            </q-avatar>
          </q-item-section>
          <q-item-section class="font">เข้าสู่ระบบ</q-item-section>
        </q-item>

        <q-item clickable v-ripple @click="Logout()">
          <q-item-section avatar>
            <q-avatar rounded>
              <img
                src="https://cdn-icons-png.flaticon.com/512/7756/7756285.png"
              />
            </q-avatar>
          </q-item-section>
          <q-item-section class="font">ออกจากระบบ</q-item-section>
        </q-item>

        
      </q-list>

    </q-drawer>

    <!-- แสดงข้อมูลทั้งหมดหน้าเว็บ -->
    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
// import EssentialLink from "components/EssentialLink.vue";
// const linksData = [
//   {
//     // title: 'Home',
//     // caption: 'Back to Home page',
//     // icon: 'img:https://cdn-icons-png.flaticon.com/512/2544/2544087.png',
//   },
//   {
//     // title: 'Add',
//     // caption: 'Add Information',
//     // icon: 'img:https://cdn-icons-png.flaticon.com/512/863/863823.png',
//     // link: 'http://localhost:8080/#/pages/add.vue'
//   },
// ];

export default {
  name: "MainLayout",

  // components: {
  //   EssentialLink,
  // },

  data() {
    return {
      leftDrawerOpen: false,
    };
  },

  methods: {
    ToAdd() {
      this.$router.replace({ path: "/add" });
    },

    ToIndex() {
      this.$router.replace({ path: "/" });
      this.$q.loading.show({
        message: "กำลังโหลด",
      });
    },

    Login(){
      this.$router.replace({ path: "/Login" });
    },

    Logout(){
       this.$router.replace({ path: "/Logout" });
    },

  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Kanit&family=Prompt&display=swap");
.q-item__label--header {
  color: #757575;

  padding: 16px;
  font-size: 2rem;
  font-family: "Kanit", sans-serif;
  line-height: 1.25rem;
  font-weight: bolder;
  letter-spacing: 0.2em;
}

.font {
  font-family: "Kanit", sans-serif;
  font-weight: bolder;
  font-size: 1rem;
  letter-spacing: 0.1em;
}
</style>
