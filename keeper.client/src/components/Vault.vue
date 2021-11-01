<template>
  <div class="col-md-2">
    <div class="card">
      <img src="https://1.bp.blogspot.com/-2Hkk5c3wqr4/X-GetMwxKTI/AAAAAAAAVHQ/CNPABYbLclEtpGjNiD8b77c4INVdNxSpwCLcBGAsYHQ/s16000/cyb-sec.png" alt="">
    {{vault.name}}
    {{vault.description}}
    </div>

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