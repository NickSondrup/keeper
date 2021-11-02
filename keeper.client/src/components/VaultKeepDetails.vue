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
           <button class="btn btn-outline-dark" @click="removeVaultKeep()" v-if="keep.creatorId == account.id">
             remove from vault
           </button>
          </div>
          <i v-if="account.id == keep.creatorId" class="mdi mdi-delete-outline fs-3 m-auto selectable" title="delete" @click="deleteKeep(keep.id)"></i>
          <div class="d-flex">
              <img :src="keep.creator.picture" height="45" class="rounded m-auto" alt="">
            <p class="fw-bold m-2 text-break">{{keep.creator.name}}</p>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>


<script>
import { computed, ref } from '@vue/reactivity'
import { AppState } from '../AppState.js'
import { Modal } from 'bootstrap'
import Pop from '../utils/Pop.js'
import { keepsService } from '../services/KeepsService.js'
import { logger } from '../utils/Logger.js'
import { vaultsService } from '../services/VaultsService.js'
export default {
  props: {
    keep: { type: Object, defualt: () => {return new Object()}}
    },
  setup(props){
    const editable = ref({}) 
    return {
      editable,
      userVaults: computed(() => AppState.userVaults),
      account: computed(() => AppState.account),
      async deleteKeep(keepId) {
        try {
          if(await Pop.confirm()) {
            const modal = Modal.getOrCreateInstance(document.getElementById(`keep-details-${keepId}`))
            modal.hide()
            await keepsService.deleteKeep(keepId)
            Pop.toast('keep deleted!', 'success')
          }
        } catch (error) {
          Pop.toast(error.message, 'error')
        }
      },

      async removeVaultKeep() {
        try {
          if(await Pop.confirm()) {
            const modal = Modal.getOrCreateInstance(document.getElementById(`keep-details-${props.keep.id}`))
            modal.hide()
            await vaultsService.removeVaultKeep(props.keep.vaultKeepId)
            Pop.toast('Keep Removed from Vault!', 'success')
          }
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