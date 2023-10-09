<script setup lang="ts">
    import HelloWorld from './components/HelloWorld.vue'
    import TheWelcome from './components/TheWelcome.vue'
    import Index from './components/Index.vue'
    import TerminoVue from './components/TerminoVue.vue'
</script>

<template>
    <header>
        <img alt="Vue logo" class="logo" src="./assets/imgbin_mars-png.png" width="150" height="150" />

        <div class="wrapper">
            <HelloWorld msg="You did it!" />
        </div>
    </header>

    <main>
        <TerminoVue />
        <h2>Example</h2>
        <pre>
Input:

5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
        </pre>
        <pre>
Output:

1 3 N
5 1 E
        </pre>
        <div>
            Note: There is bugs. I am aware of them. Creating this has been a rewarding opportunity to explore JS terminal console interfaces and challenges, as well as some .NET concepts, and other approaches to reimplimenting.
            -Boundary checking being one of them. see the README.MD file

        </div>
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
