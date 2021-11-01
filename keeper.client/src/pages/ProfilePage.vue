<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <img :src="profile.picture" alt="">
        <h1>{{profile.name}}</h1>
        <h6 v-if="vaults">Keeps: {{keeps.length}}</h6>
        <h6>Vaults: {{vaults.length}}</h6>
      </div>
      <div class="col-1 d-flex ">
        <h1>Keeps</h1>
        <i class="mdi mdi-plus fs-1 m-auto text-success selectable" title="Create Keep" data-bs-toggle="modal" data-bs-target="#keep-form"></i>
      </div>
    </div>
    <div class="row">
      <Vault v-for="v in vaults" :key="v.id" :vault="v" />
    </div>
    <div class="row">
      <ProfileKeep v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>

  <Modal id="keep-form">
    <template #modal-body>
      <KeepForm />
    </template>
  </Modal>
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