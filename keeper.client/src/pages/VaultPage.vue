<template>
  <div class="container-fluid">
    <div class="row my-5">
      <h1>{{vault.name}}</h1>
      <h4>{{vault.description}}</h4>
    </div>
    <div class="row">
      <Keep v-for="k in vaultKeeps" :key="k.id" :keep="k" />
    </div>

  </div>
</template>


<script>
import { computed, onMounted, watchEffect } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService.js'
import Pop from '../utils/Pop.js'
import { AppState } from '../AppState.js'
import { keepsService } from '../services/KeepsService.js'
export default {
  setup(){
    const route = useRoute()

    onMounted( async() => {
      if(route.params.vaultId)
      try {
        await vaultsService.getVault(route.params.vaultId)
      } catch (error) {
        Pop.toast(error.message)
      }
      try {
        await keepsService.getVaultKeeps(route.params.vaultId)
      } catch (error) {
        Pop.toast(error.message)
      }
    })
    return {
      vault: computed(()=> AppState.vault),
      vaultKeeps: computed(()=> AppState.vaultKeeps)
    }
  }
}
</script>


<style lang="scss" scoped>

</style>