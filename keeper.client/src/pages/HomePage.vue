<template>
<div class="container-fluid">
  <div class="row">

  <div class="masonry-container my-5">
    <div class="">
      <Keep v-for="k in keeps" :key="k.id" :keep="k"/>
    </div>
  </div>
  </div>
</div>
</template>

<script>
import { computed, onMounted, watchEffect } from '@vue/runtime-core'
import Pop from '../utils/Pop.js'
import { keepsService } from '../services/KeepsService.js'
import { AppState } from '../AppState.js'
export default {
  name: 'Home',
  setup() {
    onMounted( async () =>{
      try {
        await keepsService.getKeeps()
      } catch (error) {
        Pop.toast(error.message, 'error')
      }
    })
    return{
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">
.masonry-container{
  columns: 4 200px;
}

</style>
