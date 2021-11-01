<template>
  <div class="container-fluid mt-3">
    <div class="row">
      <Keep v-for="k in keeps" :key="k.id" :keep="k"/>
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
    onMounted(() =>{
      try {
        keepsService.getKeeps()
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
.container-fluid{
  column-count: 4;
}

</style>
