<template>
  <div class="container">
    <div class="row">
      <div class="col-6">
        <img :src="keep.img" alt="" class="rounded img-fluid">
      </div>
      <div class="col-6 d-flex flex-column justify-content-between">
        <div class="">
          <div class="d-flex justify-content-around mx-5 px-5">
            <div>
              <i class="mdi mdi-eye" title="views"></i>
              <span>{{keep.views}}</span>
            </div>
            <div>
              <i class="mdi mdi-lock-plus" title="keeps"></i>
              <span>{{keep.keeps}}</span>
            </div>
            <div>
              <i class="mdi mdi-share-variant" title="shares"></i>
              <span>{{keep.shares}}</span>
            </div>
          </div>
          <div class="text-center my-3">
            <h1>{{keep.name}}</h1>
          </div>
          <div class="border-bottom border-dark mx-2">
            <p class="py-3">{{keep.description}}</p>
          </div>
        </div>
        <div class="d-flex justify-content-between">
          <div>
            <button class="btn btn-success">Add to Vault</button>
          </div>
          <i class="mdi mdi-delete-outline fs-3 m-auto" title="delete"></i>
        </div>

      </div>
    </div>
  </div>
</template>


<script>
export default {
  props: {
    keep: { type: Object, defualt: () => {return new Object()}}
    },
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>