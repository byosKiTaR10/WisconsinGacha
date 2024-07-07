<template>
  <div class="flex flex-wrap justify-center gap-4 bg-gray-900 p-4 md:gap-10">
    <Circle text="Home" imageUrl="src/assets/Home.png" color="black" size="text-xl" />
    <Circle text="Shop" imageUrl="src/assets/Home.png" color="black" size="text-xl" />
    <p class="text-xl font-bold underline border-black md:text-3xl">WisconsinGacha</p>
    <Circle text="Perfil" imageUrl="src/assets/Home.png" color="blue-500" size="text-xl" />
    <Circle text="Colecion" imageUrl="src/assets/Home.png" color="blue-500" size="text-xl" />
    <Circle text="Mi Pollita" imageUrl="src/assets/Home.png" color="red-500" size="text-xl" />
  </div>
</template>

<script setup>
import Circle from '../circle/circle.vue';
</script>
