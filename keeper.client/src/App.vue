<template>
  <header>
    <Navbar />
  </header>
  <main class="bg-turq-dark">
    <router-view />
  </main>
  <footer class="bg-turq">
    <div class="text-turq-light text-center p-4">
      <p class="fw-bold">
        Made with much 💖 by Nick Sondrup
      </p>
    </div>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
.bg-turq {
  background-color: #137e8e;
}
.bg-turq-dark {
  background-color: #020c0e
}
.text-turq-dark {
  color: #020c0e;
}

</style>
