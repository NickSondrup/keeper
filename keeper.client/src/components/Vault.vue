<template>
  <div class="col-md-2">
    <router-link :to="{name: 'Vault', params: {vaultId: vault.id} }">
      <div class="card vault-card selectable my-2 rounded">
        <img :src="vault.coverImg" alt="" class="rounded">
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
    return {
      
    }
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