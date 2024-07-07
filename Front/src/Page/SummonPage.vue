<template>
  <section class="h-screen w-screen bg-universo">
    <Navbar class="h-1/6"/>
    <main class="grid gap-1 h-5/6">
      <!-- Primeros 2 planetas -->
      <section class="grid grid-cols-2">
        <div class="flex justify-end" v-for="(planeta, index) in planetas.slice(0, 2)" :key="index">
          <Planet :imageUrl="planeta.img"></Planet>
        </div>
      </section>
      <!-- Tercer planeta -->
      <section  class="grid grid-cols-1 ">
        <div class="flex justify-end" v-if="planetas.length > 2">
          <Planet :imageUrl="planetas[2].img"></Planet>
        </div>
      </section>
      <!-- Planetas restantes -->
      <section class="grid grid-cols-3 gap-1">
        <div class="flex justify-center" v-for="(planeta, index) in planetas.slice(3)" :key="index + 3">
          <Planet :imageUrl="planeta.img"></Planet>
        </div>
      </section>
    </main>
  </section>
</template>


<script setup>
import { computed, ref } from "vue";
import Navbar from "../components/navbar/navbar.vue";
import Planet from "../components/planet/planet.vue";
import {getAllCards} from "../service/cards.js"

const showTooltip = ref(false)

const planetas = [{ img: "src/assets/planetas/dbz.png", name: "funca", description: "funca" },
{ img: "src/assets/planetas/dbz.png", name: "funca", description: "funca" },
{ img: "src/assets/planetas/Luffy-removebg-preview.png", name: "funca", description: "funca" },
{ img: "src/assets/planetas/dbz.png", name: "funca", description: "funca" },
{ img: "src/assets/planetas/saitama.png", name: "funca", description: "funca" },
{ img: "src/assets/planetas/Luffy-removebg-preview.png", name: "funca", description: "funca" }]

const handlePlanet = computed( async () => {

 const data = await getAllCards()
 let carta = data[0].name
return carta
})


</script>

<style lang="scss" scoped></style>
