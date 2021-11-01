<template>
<form @submit.prevent="createKeep()">
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
    <label for="img">Image Url</label>
    <input type="text"
           v-model="editable.img"
           id="img"
           class="form-control"
           placeholder="URL..."
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
  <div class="btn-group">
      <button type="submit" class="btn btn-success selectable mt-4">
        <b>Submit</b>
      </button>
    </div>
</form>
</template>


<script>
import { ref } from '@vue/reactivity'
import { keepsService } from '../services/KeepsService.js'
import Pop from '../utils/Pop.js'
import { Modal } from 'bootstrap'
export default {
  setup(){
    const editable = ref({})
    return {
      editable,

      async createKeep(){
        try {
          await keepsService.createKeep(editable.value)
          editable.value = {}
          Pop.toast("You've created a Keep!")
          const modal = Modal.getOrCreateInstance(document.getElementById('keep-form'))
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