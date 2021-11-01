<template>
<div class="mb-3">
  <div class="card keep-card selectable">
    <img :src="keep.img" alt="" class="rounded keep-img" data-bs-toggle="modal" :data-bs-target="'#keep-details-' + keep.id" @click="getById(keep.id)">
    <div class="card-title">
      <router-link :to="{ name: 'Profile', params:{profileId: keep.creatorId} }">
        <div class="d-flex justify-content-between">
          <h5 class="fw-bolder mt-2 text-light">{{keep.name}}</h5>
          <img :src="keep.creator.picture" height="50" class="rounded-circle" alt="">
        </div>
      </router-link>
    </div>
  </div>
</div>

<Modal :id="'keep-details-' + keep.id">
  <template #modal-body>
    <KeepDetails :keep="keep" />
  </template>
</Modal>
</template>


<script>
import { computed, ref, watchEffect } from '@vue/runtime-core'
import { keepsService } from '../services/KeepsService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
import { AppState } from '../AppState.js'
export default {
  props: {
    keep: { type: Object, default: () => {return new Object()}}
    },
  setup(props){
    // let editable = ref({})
    return {
      // editable,
      // addView() {
      //   props.keep.views ++
      //   editable = {...props.keep}
      //   keepsService.addView(editable)
      // }
      async getById(keepId){
        try {
          props.keep.views ++
          await keepsService.getById(keepId)
        } catch (error) {
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.keep-card{
  position: relative;
  color: white;
}
.card-title{
 position: absolute;
 bottom: 1%;
 left: 5%;
}
.keep-img{
  width: 100%
}

</style>