<template>
  <div class="col-md-2">
    <router-link :to="{name: 'Vault', params: {vaultId: vault.id} }">
      <div class="card vault-card selectable my-2">
        <img src="https://1.bp.blogspot.com/-2Hkk5c3wqr4/X-GetMwxKTI/AAAAAAAAVHQ/CNPABYbLclEtpGjNiD8b77c4INVdNxSpwCLcBGAsYHQ/s16000/cyb-sec.png" alt="">
        <div class="vault-title">
          <h5>{{vault.name}}</h5>
        </div>
      </div>
    </router-link>
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
.vault-card{
  position: relative;
  color: white;
}
.vault-title{
 position: absolute;
 bottom: 1%;
 left: 5%;
}
</style>