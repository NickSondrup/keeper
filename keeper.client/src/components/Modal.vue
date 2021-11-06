<template>
 <div class="modal fade text-light m-0" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl rounded-3 border border-primary border-3">
      <div class="modal-content border-0">
        <div class="modal-body bg-turq-dark rounded">
          <div class="d-flex justify-content-end">
           <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <slot name="modal-body"></slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {
    return {}
  }
}
</script>

<style lang="scss" scoped>
.text-turq-dark {
  color: #020c0e;
}

</style>