<template>
  <section class="bg-gray-600 h-screen w-screen">
    <Navbar />
    <main class="flex justify-center items-center p-10">
    <Banner />
</main>
  </section>
</template>

<script setup>
import Navbar from "../components/navbar/navbar.vue";
import Banner from "../components/banner/banner.vue";
</script>

<style lang="scss" scoped></style>
