<template>
  <header>
    <Navbar />
  </header>
  <main class="bg-stone">
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
.bg-stone {
  background-image: url(https://thumbs.dreamstime.com/b/modern-dark-brick-wall-pattern-decorative-stone-wall-background-surface-black-wall-texture-modern-dark-brick-wall-pattern-174545922.jpg);
}
.text-turq-dark {
  color: #020c0e;
}

</style>
