<template>
  <div class="component">
    <form @submit.prevent="createVault()">
      <div class="form-group">
        <label for="name">Title</label>
        <input type="text"
              v-model="editable.name"
              id="name"
              class="form-control"
              placeholder="Title..."
        >
      </div>
      <div class="form-group">
        <label for="description">Description</label>
        <input type="text"
              v-model="editable.description"
              id="description"
              class="form-control"
              placeholder="Description..."
        >
      </div>
      <div class="form-group">
        <label for="coverImg">Cover Image</label>
        <input type="text"
              v-model="editable.coverImg"
              id="coverImg"
              class="form-control"
              placeholder="Cover Image URL..."
        >
      </div>
      <div class="form-group">
        <input type="checkbox"
              v-model="editable.isPrivate"
              id="isPrivate"
              class=""
        >
        <label for="isPrivate">Private?</label>
      </div>
      <div class="btn-group">
          <button type="submit" class="btn btn-success selectable mt-4">
            <b>Submit</b>
          </button>
        </div>
    </form>

  </div>
</template>


<script>
import { ref } from '@vue/reactivity'
import Pop from '../utils/Pop.js'
import { vaultsService } from '../services/VaultsService.js'
import { Modal } from 'bootstrap'
import { useRoute } from 'vue-router'
export default {
  setup(){
    const editable = ref({})
    const route = useRoute()
    return {
      editable,

      async createVault(){
        try {
          await vaultsService.createVault(editable.value, route.params.profileId)
          editable.value = {}
          Pop.toast("You've created a Vault!")
          const modal = Modal.getOrCreateInstance(document.getElementById('vault-form'))
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