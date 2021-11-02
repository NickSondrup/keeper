<template>
<div class="my-2 masonry">
  <div class="card keep-card selectable" data-bs-toggle="modal" :data-bs-target="'#keep-details-' + keep.id" @click="getById(keep.id)">
    <img :src="keep.img" alt="" class="rounded img-fluid">
    <div class="card-title">
      <div class="d-flex justify-content-between">
        <h5 class="fw-bolder mt-2">{{keep.name}}</h5>
      </div>
    </div>
  </div>
</div>

<Modal :id="'keep-details-' + keep.id">
  <template #modal-body>
    <ProfileKeepDetails :keep="keep" />
  </template>
</Modal>
</template>


<script>
import { ref, watchEffect } from '@vue/runtime-core'
import { keepsService } from '../services/KeepsService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
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
 bottom: 1%
}
.masonry{
  display: inline-block;
  width: 100%;
}

</style>