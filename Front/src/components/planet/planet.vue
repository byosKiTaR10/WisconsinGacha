<template>
  <section class="h-full ml-10 w-4/5 sm:w-3/5 m-0">
    <div class="h-1/4 2xl: w-5/6 relative">
      <span v-if="showTooltip" class="absolute text-white p-1 rounded w-full">
        <p class="text-sm md:text-3xl ">{{ name }}</p>
        <p class="hidden  sm:block">{{ description }}</p>
      </span>
    </div>
    <button class="h-2/4 sm:h-3/4 "
      :class="buttonClass"
      :style="backgroundStyle"
      @mouseover="showTooltip = true"
      @mouseleave="showTooltip = false"
    >
    </button>
  </section>
</template>

<script setup>
import { ref, computed } from 'vue'

const props = defineProps({
  imageUrl: {
    type: String,
    default: ''
  },
  size: {
    type: String,
    default: 'text-base'
  },
  name: {
    type: String,
    default: 'No hay nombre'
  },
  description: {
    type: String,
    default: 'No hay descripcio ldsdfdggdfgdfgdfgdfgfdsfdsfdsfsdfdsf'
  },
})

const showTooltip = ref(false)

const backgroundStyle = computed(() => {
  return props.imageUrl
    ? { backgroundImage: `url(${props.imageUrl})`, backgroundSize: 'contain', backgroundPosition: 'center', filter: "brightness(70%)", backgroundRepeat: "no-repeat" }
    : {}
})

const buttonClass = computed(() => {
  return [
    'w-2/4', 'rounded-full', 'flex', 'items-center', 'justify-center', 'focus:outline-none',
    props.imageUrl ? '' : 'bg-white'
  ]
})
</script>

<style scoped>
button:focus {
  outline: none;
}
</style>
