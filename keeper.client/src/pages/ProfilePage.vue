<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <img :src="profile.picture" alt="">
        <h1>{{profile.name}}</h1>
      </div>
    </div>
    <div class="row">
      <Vault v-for="v in vaults" :key="v.id" :vault="v" />
    </div>
    <div class="row">
      <ProfileKeep v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>
</template>


<script>
import { computed, watchEffect } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { profilesService } from '../services/ProfilesService.js'
import Pop from '../utils/Pop.js'
import { AppState } from '../AppState.js'
export default {
  setup(){
    const route = useRoute()

    watchEffect(async() =>{
      if(route.params.profileId)
      try {
        await profilesService.getProfile(route.params.profileId)
      } catch (error) {
        Pop.toast(error.message)
      }
      try {
        await profilesService.getVaults(route.params.profileId)
      } catch (error) {
        Pop.toast(error.message)
      }
      try {
        await profilesService.getKeeps(route.params.profileId)
      } catch (error) {
        Pop.toast(error.message)
      }
    })
    return {
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>


<style lang="scss" scoped>

</style>