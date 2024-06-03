<template>
  <section class="bg-universo h-screen w-screen">
    <Navbar />
    <main class="grid grid-cols-10 grid-rows-10 gap-4 p-10">
      <Planet v-for="index in 20" :key="index" imageUrl="src/assets/planetas/dbz.png" />
    </main>
  </section>
</template>

<script setup>
import Navbar from "../components/navbar/navbar.vue";
import Planet from "../components/planet/planet.vue";

let PlanetObject = []


</script>

<style lang="scss" scoped></style>

