<template>
  <div class="q-pa-md fontAdd">
    <q-form class="q-gutter-md">
      <q-item-label class="Add q-pa-lg">เพิ่มข้อมูลสินค้า</q-item-label>

      <div class="row">
        <div class="col-12 col-md-8 q-pa-md">
          <q-input
            rounded
            filled
            v-model="spC_ITEMNAME"
            label="ชื่อสินค้า"
            lazy-rules
            :rules="[(val) => (val && val.length > 0) || 'กรุณาใส่ชื่อสินค้า']"
          >
            <template v-slot:prepend>
              <q-icon>
                <img
                  src="https://cdn-icons-png.flaticon.com/512/1367/1367686.png"
                />
              </q-icon>
            </template>
          </q-input>
        </div>

        <div class="col-12 col-md-2 q-pa-md">
          <q-input
            rounded
            filled
            v-model="spC_PRICEGROUP3"
            label="ราคา"
            lazy-rules
            :rules="[(val) => (val && val.length > 0) || 'กรุณาใส่ราคาสินค้า']"
          >
            <template v-slot:prepend>
              <q-icon>
                <img
                  src="https://cdn-icons-png.flaticon.com/512/2450/2450176.png"
                />
              </q-icon>
            </template>
          </q-input>
        </div>

        <div class="col-12 col-md-2 q-pa-md">
          <q-input
            rounded
            filled
            v-model="unitid"
            label="หน่วย"
            lazy-rules
            :rules="[(val) => (val && val.length > 0) || 'กรุณาใส่หน่วยสินค้า']"
          ></q-input>
        </div>
      </div>

      <div class="row">
        <div class="col-12 col-md-4 q-pa-md">
          <q-input
            rounded
            filled
            v-model="itembarcode"
            label="บาร์โค้ด"
            lazy-rules
            :rules="[
              (val) =>
                (val && val.length > 0) || 'กรุณาใส่เลขบาร์โค้ดของสินค้า',
            ]"
          >
            <template v-slot:prepend>
              <q-icon>
                <img
                  src="https://cdn-icons-png.flaticon.com/512/3050/3050199.png"
                />
              </q-icon>
            </template>
          </q-input>
        </div>

        <div class="col-12 col-md-4 q-pa-md">
          <q-input rounded filled v-model="itemid" label="รหัสสินค้า">
          </q-input>
        </div>

        <div class="col-12 col-md-4 q-pa-md">
          <q-input rounded filled v-model="inventdimid" label="มิติสินค้า">
          </q-input>
        </div>
      </div>

      <div class="row">
        <div class="col-12 col-md-6 q-pa-md">
          <q-select
            rounded
            filled
            v-model="spC_ITEMBUYERGROUPID"
            :options="options"
            label="รหัสแผนก/รหัสจัดซื้อ"
            emit-value
            map-options
            :option-value="
              (opt) => (Object(opt) === opt && 'num' in opt ? opt.num : null)
            "
            :option-label="
              (opt) => (Object(opt) === opt && 'name' in opt ? opt.name : '')
            "
          >
          </q-select>
        </div>
      </div>

      <div class="row">
        <div class="col-12 col-md-6 q-pa-md">
          <q-select
            rounded
            filled
            v-model.number="spC_ITEMACTIVE"
            label="สถานะสินค้า(1กับ0)"
            :options="options_spC_ITEMACTIVE"
          >
          </q-select>
        </div>

        <div class="col-12 col-md-6 q-pa-md">
          <q-input rounded filled v-model="spC_IMAGEPATH" label="รูปภาพ">
            <template v-slot:prepend>
              <q-icon>
                <img
                  src="https://cdn-icons-png.flaticon.com/512/4598/4598380.png"
                />
              </q-icon>
            </template>
          </q-input>
        </div>
      </div>

      <q-toggle v-model="accept" label="ยอมรับเงื่อนไขที่กำหนด" />

      <div class="column items-end">
        <div class="col"></div>
        <div class="col">
          <q-btn
            push
            color="red-11"
            label="บันทึก"
            class="q-ma-md"
            icon="save"
            @click="btnsave = true"
          >
          </q-btn>
          <q-btn
            color="red-6"
            label="รีเซ็ต"
            class="q-ma-md"
            icon="cloud_upload"
            @click="onReset()"
          ></q-btn>
        </div>
      </div>

      <q-dialog v-model="btnsave">
        <q-card>
          <q-card-section>
            <div class="text-h6 fontpopup">
              <strong>ยืนยันการบันทึก</strong>
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
            <div class="fontpop">
              <q-avatar icon="warning" color="red" />
              ต้องการบันทึกข้อมูลหรือไม่
            </div>
          </q-card-section>

          <div class="column items-end">
            <div class="col"></div>
            <div class="col fontpop q-ma-md">
              <q-btn flat label="ใช่" @click="warning()" v-close-popup> </q-btn>
              <q-btn flat label="ไม่" v-close-popup> </q-btn>
            </div>
          </div>
        </q-card>
      </q-dialog>
    </q-form>
  </div>
</template>

<script>
import axios from "axios";

var data = {
  itembarcode: "",
  spC_ITEMNAME: "",
  spC_PRICEGROUP3: "",
  unitid: "",
  itemid: "",
  spC_ITEMBUYERGROUPID: "",
  primaryvendorid: "",
  spC_IMAGEPATH: "",
  inventdimid: "",
  name: "",
  description: "",
  spC_ITEMACTIVE: "",
};

export default {
  data() {
    return {
      data,
      spC_ITEMNAME: "",
      spC_PRICEGROUP3: "",
      itembarcode: "",
      unitid: "",
      itemid: "",
      inventdimid: "",
      spC_ITEMBUYERGROUPID: "",
      primaryvendorid: "",
      name: "",
      vmodeldescription: "",
      spC_IMAGEPATH: "",
      spC_ITEMACTIVE: "",

      accept: false,
      file: null,
      btnsave: false,

      options: [],

      options_spC_ITEMACTIVE: ["1", "0"],
    };
  },

  mounted() {
    this.Department();
  },

  // mounted() {
  //   this.Department1()
  // },

  //   computed () {
  //     console.log("compute")
  // console.log(this.spC_ITEMBUYERGROUPID)
  //   },

  //ดูข้อมูลว่าที่คลิ๊กใช่แผนกที่ที่เลือกไหมโดยการใช้ watch
  watch: {
    spC_ITEMBUYERGROUPID(newvalue, oldvalue) {
      console.log(newvalue.num);
      console.log(oldvalue.num);
    },
  },

  methods: {
    Department() {
      //ดึงแผนกทั้งหมดมาโดยใช้โดย api ที่สร้างแยกมา
      axios
        .get("BarCodeAPI/api/Product/NUMS")
        .then((e) => {
          console.log(e.data);
          this.options = e.data;
        })
        .catch((error) => {
          this.alert(error);
        });
    },

    //ปุ่มกดบันทึก ไม่ใช้
    // onSubmit() {
    //   if (this.accept !== true) {
    //     this.$q.notify({
    //       color: "red-5",
    //       textColor: "white",
    //       icon: "warning",
    //       message: "กรุณากดยอมรับเงื่อนไข",
    //     });
    //   }

    //   else {
    //     this.$q.notify({
    //       color: "green-4",
    //       textColor: "white",
    //       icon: "cloud_done",
    //       message: "บันทึกเรียบร้อย",
    //     });

    //   }
    // },

    //ปุ่มเครียข้อมูลเมื่อบันทึกเสร็จ
    onReset() {
      this.spC_ITEMNAME = "";
      this.spC_PRICEGROUP3 = "";
      this.itembarcode = "";
      this.unitid = "";
      this.itemid = "";
      this.inventdimid = "";
      this.spC_ITEMBUYERGROUPID = "";
      (this.name = ""),
        (this.spC_IMAGEPATH = ""),
        (this.spC_ITEMACTIVE = ""),
        (this.primaryvendorid = ""),
        (this.vmodeldescription = ""),
        (this.accept = false);
    },

    //การกดบันทึก

    //ฟังก์ัชันการดักerror ก่อนบันทึกห้ามมีช่องว่าง
    warning() {
      if (
        this.spC_ITEMNAME.length > 0 &&
        this.spC_ITEMNAME != null &&
        this.spC_ITEMNAME != "" &&
        this.spC_PRICEGROUP3.length > 0 &&
        this.spC_PRICEGROUP3 != null &&
        this.spC_PRICEGROUP3 != "" &&
        this.unitid.length > 0 &&
        this.unitid != null &&
        this.unitid != "" &&
        this.itembarcode.length > 0 &&
        this.itembarcode != null &&
        this.itembarcode != ""
      ) {
        this.save();
      } else {
        this.$q
          .dialog({
            title: "แจ้งเตือน",
            message: ">>>>>>>>>> กรุณาเพิ่มข้อมูลสินค้า",
            persistent: true,
          })
          .onOk(() => {
            console.log(">>>> OK");
          });
      }
    },

    save() {
      //โชว์ข้อมูลว่ามีข้อมูลเข้าไหม
      console.log("-----save-----");
      console.log(
        this.itembarcode,
        this.itemid,
        this.inventdimid,
        this.unitid,
        this.spC_PRICEGROUP3,
        this.spC_ITEMNAME,
        this.spC_IMAGEPATH,
        this.spC_ITEMBUYERGROUPID,
        this.spC_ITEMACTIVE,
        this.name,
        this.vmodeldescription
      );
      console.log("-----save-----");

      data = {
        itembarcode: this.itembarcode,
        itemid: this.itemid,
        inventdimid: this.inventdimid,
        unitid: this.unitid,
        spC_PRICEGROUP3: this.spC_PRICEGROUP3,
        spC_ITEMNAME: this.spC_ITEMNAME,
        spC_IMAGEPATH: this.spC_IMAGEPATH,
        spC_ITEMBUYERGROUPID: this.spC_ITEMBUYERGROUPID,
        spC_ITEMACTIVE: this.spC_ITEMACTIVE,
        // primaryvendorid: this.primaryvendorid,
        // name: this.name,
        // description: this.vmodeldescription,
      };

      console.log(data);
      console.log(this.spC_ITEMBUYERGROUPID);

      axios
        .post("BarCodeAPI/api/Product/InsertBarCode", data)

        .then((e) => {
          console.log(e);
          this.onReset();
        })
        .catch((error) => {
          console.log("ผิด" + error.message);
          //this.alert(error);
        });
    },
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Kanit&family=Prompt&display=swap");
.black {
  background: rgb(228, 227, 227);
}
.fontAdd {
  font-family: "Kanit", sans-serif;
}
.Add {
  font-size: 2rem;
}
</style>
