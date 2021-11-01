<template>
  <div class="col-md-2">
    {{vault.name}}

  </div>
</template>


<script>
export default {
  props: {
    vault: { type: Object, default: () => { return new Object()}}
  },
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>