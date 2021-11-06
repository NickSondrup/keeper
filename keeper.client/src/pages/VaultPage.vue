<template>
  <div class="container-fluid text-light">
    <div class="row m-5">
      <div class="col-12 d-flex justify-content-between">
      <div>
        <h1>{{vault.name}}</h1>
        <h4>{{vault.description}}</h4>
      </div>
      <div>
        <button v-if="account.id == vault.creatorId" class="btn btn-outline-secondary mt-4" type="button" @click="deleteVault(vault.id, vault.creatorId)">
          Delete Vault
        </button>
      </div>
      </div>
    </div>

  </div>
    <div class="masonry-container mx-3">
      <VaultKeep v-for="k in vaultKeeps" :key="k.id" :keep="k" />
    </div>
</template>


<script>
import { computed, onMounted, watchEffect } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService.js'
import Pop from '../utils/Pop.js'
import { AppState } from '../AppState.js'
import { keepsService } from '../services/KeepsService.js'
import { router } from '../router.js'
export default {
  setup(){
    const route = useRoute()

    onMounted( async() => {
      if(route.params.vaultId)
      try {
        await vaultsService.getVault(route.params.vaultId)
      } catch (error) {
        Pop.toast(error.message, 'error')
        router.push({ name: 'Home'})
      }
      try {
        await keepsService.getVaultKeeps(route.params.vaultId)
      } catch (error) {
        Pop.toast(error.message)
      }
    })
    return {
      vault: computed(()=> AppState.vault),
      vaultKeeps: computed(()=> AppState.vaultKeeps),
      account: computed(() => AppState.account),
      async deleteVault(vaultId, creatorId) {
        try {
          if(await Pop.confirm()){
            await vaultsService.deleteVault(vaultId, creatorId)
            Pop.toast('Vault was deleted', 'success')
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
.masonry-container{
  columns: 4 200px;
}
</style>