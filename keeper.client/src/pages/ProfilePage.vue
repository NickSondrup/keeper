<template>
  <div class="container-fluid text-light">
    <div class="row py-5 bg-picture" :style="{backgroundImage: `url(${profile.coverImg})`}">
      <div class="col-md-2">
        <img :src="profile.picture" alt="profile picture" class="ms-5 my-5 rounded profile-picture">
      </div>
      <div class="col-md-8">
          <div class="ms-4 my-5">
            <h1>{{profile.name}}</h1>
            <h3>Vaults: {{vaults.length}}</h3>
            <h3>Keeps: {{profileKeeps.length}}</h3>
            <button class="btn btn-edit fw-bold" data-bs-toggle="modal" data-bs-target="#profile-form">Edit Profile</button>
          </div>
      </div>
    </div>
    <div class="row mt-2">
      <div class="col-12 d-flex">
        <div class="d-flex">
        <h1>Vaults</h1>
        <i v-if="account.id == profile.id" class="mdi mdi-plus fs-1 m-auto text-success selectable" title="Create Vault" data-bs-toggle="modal" data-bs-target="#vault-form"></i>
        </div>
      </div>
      <Vault v-for="v in vaults" :key="v.id" :vault="v" />
    </div>
    <div class="row mt-5">
      <div class="col-12 d-flex">
        <div class="d-flex">
        <h1>Keeps</h1>
        <i v-if="account.id == profile.id" class="mdi mdi-plus fs-1 m-auto text-success selectable" title="Create Keep" data-bs-toggle="modal" data-bs-target="#keep-form"></i>
        </div>
      </div>
    </div>
    <div class="row">

    <div class="masonry-container">
      <ProfileKeep v-for="k in profileKeeps" :key="k.id" :keep="k" />
    </div>
    </div>
  </div>

  <Modal id="keep-form">
    <template #modal-body>
      <KeepForm />
    </template>
  </Modal>
  <Modal id="vault-form">
    <template #modal-body>
      <VaultForm />
    </template>
  </Modal>
  <Modal id="profile-form">
    <template #modal-body>
      <ProfileForm :profile="profile" />
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
      account: computed(() => AppState.account),
      profileKeeps: computed(() => AppState.profileKeeps)
    }
  }
}
</script>


<style lang="scss" scoped>
.masonry-container{
  columns: 6 200px;
}
.btn-edit{
   background-color: #137e8e;
}
.profile-picture{
  max-height: 200px;
  max-width: 200px;
}
.bg-picture{
  background-position: center center;
  background-size: cover;
}
</style>