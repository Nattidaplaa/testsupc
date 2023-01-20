<template>
  <div class="q-pa-md">
      <q-item-label class="Add1 q-pa-lg">เข้าสู่ระบบ</q-item-label>

      <div class="column items-center" style="height: 220px">
      <q-form >
      <div class="col">
        
        <div class="row-12 row-md-6 q-pa-md">
          <q-input
            rounded
            filled
            v-model="employeeid"
            label="รหัสพนักงาน"
            lazy-rules
            :rules="[(val) => (val && val.length > 0) || 'รหัสพนักงานที่มีในระบบเท่านั้น']"
          >
            <template v-slot:prepend>
              <q-icon>
                <img
                  src="https://cdn-icons-png.flaticon.com/512/1308/1308491.png"
                />
              </q-icon>
            </template>
          </q-input>
        </div>

        <div class="row-12 row-md-6 q-pa-md">
           <q-input 
           rounded
           v-model="password" 
           filled 
           label="รหัสผ่าน"
           :type="isPwd ? 'password' : 'text'" 
           lazy-rules
            :rules="[(val) => (val && val.length > 0) || 'กรุณาใส่รหัสให้ถูกต้อง']"
             @keydown.enter="LoginEmployee()"
            >
           
           <!-- ปิดรหัสผ่านเพื่อไม่ให้มองเห็น -->
           <template v-slot:append>                                                                                                            
           <q-icon
            :name="isPwd ? 'visibility_off' : 'visibility'"
            class="cursor-pointer"
            @click="isPwd = !isPwd"
           
            >
            </q-icon>
        </template>

        <!-- เพิ่มรูปภาพด้านหน้าไป -->
        <template v-slot:prepend>
              <q-icon>
                <img
                  src="https://cdn-icons-png.flaticon.com/512/3427/3427189.png"
                />
              </q-icon>
            </template>

      </q-input>
        </div>

      </div>
      </q-form>
      </div>
      
       <div  class="column items-center">
         <q-btn push
            color="red-11"
            class="q-ma-md" 
            label="เข้าสู่ระบบ" 
            @click="LoginEmployee()"
            ></q-btn>
       </div>

       <div  class="column items-center">
         <q-btn push
            color="red-11"
            class="q-ma-md" 
            label="ออกจากระบบ" 
            @click="logout = true"
            ></q-btn>
       </div>

       <q-dialog v-model="logout">
        <q-card style="min-width: 250px; q-pt-none;">
            <q-card-section>
                <div class="text-h6">
                    <strong>คำเตือน</strong>
                    <q-btn
                       round
                       flat
                       dense
                       icon="close"
                       class="float-right"
                       v-close-popup
                    >
                    </q-btn>
                </div>
            </q-card-section>
            <q-card-section>
                <div>ยืนยันการออกจากระบบ</div>
            </q-card-section>
            <div class="column items-end">
          <div class="col"></div>
          <div class="col fontpop q-ma-md">
            <q-btn 
             flat label="ใช่" 
             @click="LogoutEmployee()" 
             v-close-popup
             v-go-back=" '/' "
            ></q-btn>
            <q-btn flat label="ไม่" v-close-popup> </q-btn>
          </div>
        </div>
        </q-card>
       </q-dialog>

  </div>
</template>

<script>

import axios from "axios";
import router from 'src/router';

export default {

data(){
    return{
        login: false,
        employeeid: "",
        password: "",
        isPwd: true,
        logout: false,

    }
},


methods: {

    LoginEmployee() {
      this.$q.loading.show({
        message: "กำลังโหลด",
      });
      console.log("login");
     
      axios
        .get("/BarCodeAPI/api/Product/LoginEmployee", {
          params: {
            employee: this.employeeid,
            password: this.password,
          },
        })
        .then((e) => {
          console.log(e.data[0].password);
          if(this.password == e.data[0].password){
            this.$router.replace("/").catch(() => {}); //คลิ๊กแล้วไปหน้าแรก
          }
        })
        .catch((error) => {
            console.log("ผิด" + error.message);
            this.$q.dialog({
             title: "คำเตือน",
             message: "รหัสพนักงานหรือรหัสผ่านไม่ถูกต้อง",
             cancel: true,
             persistent: true,
        })
        })
        .finally(() => {
          this.$q.loading.hide();
        });
    },

    LogoutEmployee(){
      this.employeeid = "";
      this.password = "";
      console.log("Logout");
      

    },

    

},

};

</script>


<style>
.Add1 {
  font-size: 2rem;
}</style>
