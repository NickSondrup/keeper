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
          <div class="border-bottom border-light mx-2">
            <p class="py-3">{{keep.description}}</p>
          </div>
        </div>
        <div class="d-flex justify-content-between">
          <div>
            <select name="" id="" v-model="editable.vaultId" @change="addKeepToVault()">
              <option v-for="vault in userVaults" :key="vault.id" :value="vault.id">
                {{vault.name}}
              </option>
            </select>
          </div>
          <i v-if="account.id == keep.creatorId" class="mdi mdi-delete-outline fs-3 m-auto selectable" title="delete" @click="deleteProfileKeep(keep.id)"></i>
        </div>

      </div>
    </div>
  </div>
</template>


<script>
import { Modal } from 'bootstrap'
import { keepsService } from '../services/KeepsService.js'
import Pop from '../utils/Pop.js'
import { computed, ref } from '@vue/reactivity'
import { AppState } from '../AppState.js'
import { vaultsService } from '../services/VaultsService.js'
export default {
  props: {
    keep: { type: Object, defualt: () => {return new Object()}}
    },
  setup(props){
    const editable = ref({})
    return {
      editable,
      account: computed(() => AppState.account),
      userVaults: computed(() => AppState.userVaults),
      

      async deleteProfileKeep(keepId) {
        try {
          if(await Pop.confirm()) {
            const modal = Modal.getOrCreateInstance(document.getElementById(`keep-details-${keepId}`))
            modal.hide()
            await keepsService.deleteProfileKeep(keepId)
            Pop.toast('keep deleted!', 'success')
          }
        } catch (error) {
          Pop.toast(error.message, 'error')
        }
      },
      async addKeepToVault() {
        try {
          props.keep.keeps++
          editable.value.keepId = props.keep.id
          await vaultsService.addKeepToVault(editable.value)
          Pop.toast('Keep Added to Vault!', 'success')
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