<template>
  <div id="q-app" style="background-color: #e5d1d1">
    <router-view />
  </div>
</template>

<script>
export default {
  name: "App",
};

/*
หน้าคือสามารถนำไปใช้ได้ทุกหน้า*/
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Kanit&family=Prompt&display=swap");

/* 
เรียกใช้ฟังก์ชัน(ฟ้อนต์)ทุกหน้า */

div {
  font-family: "Kanit", sans-serif;
}
</style>
