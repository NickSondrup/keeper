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
          <i class="mdi mdi-delete-outline fs-3 m-auto selectable" title="delete" @click="deleteKeep(keep.id)"></i>
        </div>

      </div>
    </div>
  </div>
</template>


<script>
import { Modal } from 'bootstrap'
import { keepsService } from '../services/KeepsService.js'
import Pop from '../utils/Pop.js'
export default {
  props: {
    keep: { type: Object, defualt: () => {return new Object()}}
    },
  setup(){
    return {
      async deleteKeep(keepId) {
        try {
          const modal = Modal.getOrCreateInstance(document.getElementById(`keep-details-${keepId}`))
          modal.hide()
          await keepsService.deleteKeep(keepId)
        } catch (error) {
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>