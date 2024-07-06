<template>
  <section class="bg-universo h-screen w-screen">
    <Navbar />
    <main class="flex flex-col gap-16 ml-32 mr-32 mt-10">
      <!-- Primeros 2 planetas -->
      <section class="flex justify-between">
        <div class="w-48 h-1/3 mr-48 ml-48" v-for="(planeta, index) in planetas.slice(0, 2)" :key="index">
          <Planet :imageUrl="planeta.img"></Planet>
        </div>
      </section>
      <!-- Tercer planeta -->
      <section class="flex justify-center">

        <div class="w-48 h-1/3" v-if="planetas.length > 2">
          <Planet :imageUrl="planetas[2].img"></Planet>
        </div>
      </section>
      <!-- Planetas restantes -->
      <section class="flex justify-between">
        <div class="w-48 h-1/3 mt-20" v-for="(planeta, index) in planetas.slice(3)" :key="index + 3">
          <Planet :imageUrl="planeta.img"></Planet>
        </div>
        {{ handlePlanet }}
      </section>
    </main>
  </section>

</template>

<script setup>
import { computed } from "vue";
import Navbar from "../components/navbar/navbar.vue";
import Planet from "../components/planet/planet.vue";
import {getAllCards} from "../service/cards.js"

const planetas = [{ img: "src/assets/planetas/dbz.png", nombre: "", descripcion: "" },
{ img: "src/assets/planetas/dbz.png", nombre: "", descripcion: "" },
{ img: "src/assets/planetas/Luffy-removebg-preview.png", nombre: "", descripcion: "" },
{ img: "src/assets/planetas/dbz.png", nombre: "", descripcion: "" },
{ img: "src/assets/planetas/saitama.png", nombre: "", descripcion: "" },
{ img: "src/assets/planetas/Luffy-removebg-preview.png", nombre: "", descripcion: "" }]

const handlePlanet = computed( async () => {

  data = await getAllCards()
  console.log(data);
return "hecho"
})


</script>

<style lang="scss" scoped></style>
