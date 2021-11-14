<template>
  <div class="component">
    <form @submit.prevent="updateProfile()">
      <div class="form-group">
        <label for="name">Name</label>
        <input type="text" 
              v-model="editable.name"
              name="name" 
              id="name" 
              class="form-control" 
              placeholder="Name..."
        >
        </div>
        <div class="form-group">
        <label for="picture">Picture Url</label>
        <input type="text" 
              v-model="editable.picture"
              name="picture" 
              id="picture"
              class="form-control"
              placeholder="Picture URL..."
        >
        </div>
        <div class="btn-group">
          <button type="submit" class="btn btn-success selectable mt-3 fw-bold">Update</button>
        </div>
    </form>

  </div>
</template>


<script>
import { ref } from '@vue/reactivity'
import Pop from '../utils/Pop.js'
import { profilesService } from '../services/ProfilesService.js'
import { Modal } from 'bootstrap'
import { useRoute } from 'vue-router'
import { watchEffect } from '@vue/runtime-core'
export default {
  props:{
    profile: { type: Object, default: () => {return new Object}}
  },
  setup(props){
    const editable = ref({})
    const route = useRoute()
    watchEffect(() => {
      editable.value = {...props.profile}
    })
    return {
      editable,

      async updateProfile(){
        try {
          await profilesService.updateProfile(editable.value, route.params.profileId)
          editable.value = {}
          Pop.toast("You've updated your profile!", 'success')
          const modal = Modal.getOrCreateInstance(document.getElementById('profile-form'))
          modal.hide()
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