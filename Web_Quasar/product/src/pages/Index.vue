<template>
  <!-- หน้า ui html -->
  <div>
    <div class="row">
      <div class="col-12 col-md-6 q-pa-md">
        <template>
          <q-btn
            class="fontpop"
            rounded
            outlined
            push
            color="blue-10"
            label="โหลดหน้านี้ใหม่"
            icon-right="img:https://cdn-icons-png.flaticon.com/512/1594/1594900.png"
            @click="loadProduct()"
          >
          </q-btn>
        </template>
      </div>

      <div class="col-12 col-md-6 q-pa-md">
        <template>
          <div class="q-pa-md">
            <div class="q-gutter-md">
              <q-input
                class="fontpop"
                rounded
                outlined
                v-model="filter"
                label="ค้นหา"
                @keydown.enter="loadProductAll()"
              >
                <!-- ต้องเปลี่ยนตัวนี้เป็นฟังก์ชันการค้นหาที่สามารถค้นหาในเบสได้ด้วย แล้วแสดงออกมาเหมือนที่ค้นหาใน form -->
                <!-- เมื่อกดค้นหาต้องกด enter แล้วจะค้นหาที่พิมพ์ไป  -->

                <template v-slot:append>
                  <q-icon name="search" />
                </template>
              </q-input>
            </div>
          </div>
        </template>
      </div>
    </div>

    <div>
      <q-table
        title="ข้อมูลสินค้า"
        :data="dataTable"
        :columns="columns"
        row-key="name"
        :rows-per-page-options="[16]"
        :loading="loading"
      >
        <template v-slot:body="props">
          <q-tr>
            <q-td>{{ props.row.spC_ITEMNAME }}</q-td>
            <q-td>{{ props.row.spC_PRICEGROUP3 }}</q-td>
            <q-td>{{ props.row.unitid }}</q-td>
            <q-td>{{ props.row.itembarcode }}</q-td>
            <q-td>{{ props.row.itemid }}</q-td>
            <q-td>{{ props.row.spC_ITEMBUYERGROUPID }}</q-td>
            <q-td>{{ props.row.description }}</q-td>
            <q-tr>
              <q-td
                ><q-btn
                  round
                  color="red-10"
                  icon="delete"
                  @click="deleteinfo(props.row.itembarcode)"
              /></q-td>
              <q-td
                ><q-btn
                  round
                  color="yellow-9"
                  icon="edit"
                  @click="showupdate(props.row)"
              /></q-td>
            </q-tr>
          </q-tr>
        </template>
      </q-table>
    </div>

    <!-- pop-up แสดงข้อความเมื่อต้องการลบ ไม่ได้ใช่ ไปใช้ใน alert แทน -->
    <!-- <q-dialog v-model="btndelete">
      <q-card style="min-width: 250px; q-pt-none;">
        <q-card-section>
          <div class="text-h6 fontpopup">
            <strong>ยืนยันการลบ</strong>
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
            ต้องการลบข้อมูลหรือไม่</div>
        </q-card-section>

        <div class="column items-end">
          <div class="col"></div>
          <div class="col fontpop q-ma-md">
            <q-btn flat label="ใช่" @click="deleteinfo()" v-close-popup > </q-btn>
            <q-btn flat label="ไม่" v-close-popup> </q-btn>
          </div>
        </div>
      </q-card>
    </q-dialog> -->

    <!-- ต้องทำการรีเซ็ทข้อมูลในการแก้ไขด้วย -->
    <!-- แสดงส่วนแก้ไข -->
    <q-dialog v-model="btnedit">
      <q-card style="min-width:1000px; q-pt-none;">
        <q-card-section>
          <div class="text-h6 fontpopup">
            <strong>แก้ไขข้อมูลสินค้า</strong>
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

        <q-separator /> 
        <!-- ตัวขีดขั้น -->

        <q-card-section>
          <div class="row fontpop">
            <div class="col-12 col-md-8 q-pa-md">
              <q-input filled v-model="spC_ITEMNAME" label="ชื่อสินค้า">
              </q-input>
            </div>

            <div class="col-12 col-md-2 q-pa-md">
              <q-input filled v-model="spC_PRICEGROUP3" label="ราคา"></q-input>
            </div>

            <div class="col-12 col-md-2 q-pa-md">
              <q-input filled v-model="unitid" label="หน่วย"></q-input>
            </div>
          </div>

          <div class="row fontpop">
            <div class="col-12 col-md-6 q-pa-md">
              <q-input filled v-model="itembarcode" label="บาร์โค้ด"> </q-input>
            </div>

            <div class="col-12 col-md-6 q-pa-md">
              <q-input filled v-model="itemid" label="รหัสสินค้า"></q-input>
            </div>
          </div>

          <div class="row fontpop">
            <div class="col-12 col-md-6 q-pa-md">
              <q-input
                filled
                v-model="inventdimid"
                label="มิติสินค้า"
              ></q-input>
            </div>
            <div class="col-12 col-md-6 q-pa-md">
              <q-input
                filled
                v-model="spC_ITEMBUYERGROUPID"
                label="รหัสแผนก/รหัสจัดซื้อ"
              ></q-input>
            </div>
          </div>

          <div class="row fontpop">
            <div class="col-12 col-md-4 q-pa-md">
              <q-input filled v-model="primaryvendorid" label="รหัสผู้จำหน่าย">
              </q-input>
            </div>

            <div class="col-12 col-md-5 q-pa-md">
              <q-input filled v-model="name" label="ชื่อผู้จำหน่าย"></q-input>
            </div>

            <div class="col-12 col-md-3 q-pa-md">
              <q-input
                filled
                v-model.number="spC_ITEMACTIVE"
                label="สถานะสินค้า(1กับ0)"
              >
              </q-input>
            </div>
          </div>

          <div class="row fontpop">
            <div class="col-12 col-md-6 q-pa-md">
              <q-input filled v-model="description" label="ชื่อจัดซื้อ">
              </q-input>
            </div>

            <div class="col-12 col-md-6 q-pa-md">
              <q-input rounded filled v-model="spC_IMAGEPATH" label="รูปภาพ">
              </q-input>
            </div>
          </div>
        </q-card-section>
        <q-separator />

        <q-card-actions align="right" class="fontpop">
          <q-btn color="indigo" flat label="อัพเดต" @click="btnupdate = true" 
           icon-right="img:https://cdn-icons-png.flaticon.com/512/1601/1601884.png" /> 
        </q-card-actions>
      </q-card>
    </q-dialog>

    <!-- ต้องการอัพเดตข้อมูลใหม่หรือไม่ -->
    <q-dialog v-model="btnupdate">
      <q-card style="min-width: 250px; q-pt-none;">
        <q-card-section>
          <div class="text-h6 fontpopup">
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
          <div class="fontpop">ยืนยันการอัพเดตข้อมูลหรือไม่</div>
        </q-card-section>

        <div class="column items-end">
          <div class="col"></div>
          <div class="col fontpop q-ma-md">
            <q-btn flat label="ใช่" @click="update()" v-close-popup></q-btn>
            <q-btn flat label="ไม่" v-close-popup> </q-btn>
          </div>
        </div>
      </q-card>
    </q-dialog>
  </div>
</template>


<script>
// คำสั่งหลังบ้าน javascript
import axios from "axios";

var product = {
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
  mounted() {
    this.loadProduct();
  },

  //ใน data จะเป็นจำนวน column ในตารางที่จะแสดงหน้าเว็บ
  data() {
    return {
      btnupdate: false,
      btndelete: false,
      btnedit: false,
      filter: "",
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
      product,
      file: null,
      loading: false,

      columns: [
        {
          name: "spC_ITEMNAME",
          align: "center",
          label: "ชื่อสินค้า", //ชื่อบน header
          sortable: true,
          field: "spC_ITEMNAME",
        },
        {
          name: "spC_PRICEGROUP3",
          align: "center",
          label: "ราคา", //ชื่อบน header
          sortable: true,
          field: "spC_PRICEGROUP3",
        },
        {
          name: "unitid",
          align: "center",
          label: "หน่วย", //ชื่อบน header
          sortable: true,
          field: "unitid",
        },
        {
          name: "itembarcode",
          align: "center",
          label: "บาร์โค้ด", //ชื่อบน header
          sortable: true,
          field: "itembarcode",
        },
        {
          name: "itemid",
          align: "center",
          label: "รหัสสินค้า", //ชื่อบน header
          sortable: true,
          field: "itemid",
        },
        {
          name: "spC_ITEMBUYERGROUPID",
          align: "center",
          label: "แผนก", //ชื่อบน header
          sortable: true,
          field: "spC_ITEMBUYERGROUPID",
        },
        {
          name: "description",
          align: "center",
          label: "ชื่อจัดซื้อ", //ชื่อบน header
          sortable: true,
          field: "description",
        },

        {
          sortable: true,
          field: "",
        },
      ],
      dataTable: [],
    };
  },

  methods: {
    //ฟังก์ชันการค้นหาข้อมมูลเพื่อดึงข้อมูลมากจากดาต้าเบส สามารถค้นหาในดาต้าเบสได้
    loadProductAll() {
      this.$q.loading.show({
        message: "กำลังโหลด",
      });
      console.log("seach");
      axios
        .get("/BarCodeAPI/api/Product/SearchBarCode1", {
          params: {
            itembarcode: this.filter,
          },
        })
        .then((e) => {
          console.log(e.data);
          this.dataTable = e.data;
        })
        .catch((error) => {
          console.log(error);
        })
        .finally(() => {
          this.$q.loading.hide();
        });
    },

    // showdelete (row) {
    //   console.log(row)
    //    this.btndelete = true;
    //         this.itembarcode = row.itembarcode
    //         this.spC_ITEMNAME = row.spC_ITEMNAME
    //         this.spC_PRICEGROUP3 = row.spC_PRICEGROUP3
    //         this.unitid = row.unitid
    //         this.itemid = row.itemid
    //         this.spC_ITEMBUYERGROUPID = row.spC_ITEMBUYERGROUPID
    //         this.primaryvendorid = row.primaryvendorid
    //         this.spC_IMAGEPATH = row.spC_IMAGEPATH
    //         this.inventdimid = row.inventdimid
    //         this.name = row.name
    //         this.description = row.description
    //         this.spC_ITEMACTIVE = row.spC_ITEMACTIVE

    // },

    deleteinfo(row) {
      this.$q
        .dialog({
          title: "คำเตือน",
          message: "ยืนยันการลบข้อมูลสินค้าหรือไม่",
          cancel: true,
          persistent: true,
        })
        .onOk(() => {
          axios
            .get("/BarCodeAPI/api/Product/DeleteBarCode", {
              params: {
                itembarcode: row,
              },
            })
            .then((e) => {
              console.log("sucsess");
              this.loadProduct();
            })
            .catch((error) => {
              console.log(error);
            });
        });
    },

    //ฟังก์ชันการอัพเดตข้อมูล

    update() {
      product = {
        itembarcode: this.itembarcode,
        spC_ITEMNAME: this.spC_ITEMNAME,
        spC_PRICEGROUP3: this.spC_PRICEGROUP3,
        unitid: this.unitid,
        itemid: this.itemid,
        spC_ITEMBUYERGROUPID: this.spC_ITEMBUYERGROUPID,
        primaryvendorid: this.primaryvendorid,
        spC_IMAGEPATH: this.spC_IMAGEPATH,
        inventdimid: this.inventdimid,
        name: this.name,
        description: this.description,
        spC_ITEMACTIVE: this.spC_ITEMACTIVE,
      };

      console.log(product);
      axios
        .post("/BarCodeAPI/api/Product/UpdateBarCode", product)
        .then((e) => {
          console.log(e);
          this.$q
            .dialog({
              title: "Confirm",
              message: "อัพเดตเรียบร้อยแล้ว",
              cancel: true,
              persistent: true,
            })
            .onOk(() => {
              // console.log('>>>> OK')
              this.loadProduct();
            })
            .onOk(() => {
              // console.log('>>>> second OK catcher')
            })
            .onCancel(() => {
              // console.log('>>>> Cancel')
            })
            .onDismiss(() => {
              // console.log('I am triggered on both OK and Cancel')
            });
          this.loadProduct();
        })
        .catch((error) => {
          console.log(error);
        });
    },

    showupdate(row) {
      console.log(row);
      this.btnedit = true;

      this.itembarcode = row.itembarcode;
      this.spC_ITEMNAME = row.spC_ITEMNAME;
      this.spC_PRICEGROUP3 = row.spC_PRICEGROUP3;
      this.unitid = row.unitid;
      this.itemid = row.itemid;
      this.spC_ITEMBUYERGROUPID = row.spC_ITEMBUYERGROUPID;
      this.primaryvendorid = row.primaryvendorid;
      this.spC_IMAGEPATH = row.spC_IMAGEPATH;
      this.inventdimid = row.inventdimid;
      this.name = row.name;
      this.description = row.description;
      this.spC_ITEMACTIVE = row.spC_ITEMACTIVE;
    },

    loadProduct() {
      this.$q.loading.show({
        message: "กำลังโหลด",
      });
      axios
        .get("/BarCodeAPI/api/Product/GetBarAll")

        .then((e) => {
          this.dataTable = e.data;
          console.log(e.data);
        })
        .catch((error) => {
          this.alert(error);
        })
        .finally(() => {
          this.$q.loading.hide();
        });
    },
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Kanit&family=Prompt&display=swap");
@import url("https://fonts.googleapis.com/css2?family=Bai+Jamjuree&family=K2D&family=Kanit&family=Prompt&display=swap");

.q-table__card {
  color: #000;
  background-color: #e5d1d1;
  border-radius: 4px;
  box-shadow: 0 1px 5px rgb(0 0 0 / 20%), 0 2px 2px rgb(0 0 0 / 14%),
    0 3px 1px -2px rgb(0 0 0 / 12%);
  font-family: "Kanit", sans-serif;
}

.fontpopup {
  font-family: "Bai Jamjuree", sans-serif;
}
.fontpop {
  font-family: "Kanit", sans-serif;
}
</style>
