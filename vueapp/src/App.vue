<script setup lang="ts">
    import HelloWorld from './components/HelloWorld.vue'
    import TheWelcome from './components/TheWelcome.vue'
    import Index from './components/Index.vue'
    import TerminoVue from './components/TerminoVue.vue'
</script>

<template>
    <header>
        <img alt="Vue logo" class="logo" src="./assets/imgbin_mars-png.png" width="150" height="150" />
        <!--<img alt="Vue logo" class="logo" src="./assets/nasa_mars_1.webp" width="125" height="125" />-->

        <div class="wrapper">
            <HelloWorld msg="You did it!" />
        </div>
    </header>

  <main>
      <!--  <TheWelcome />-->
      <!--<Index /> -->
      <TerminoVue />
  </main>
</template>

<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
