<template>
  <div class="flex flex-wrap justify-center items-center space-x-4 space-y-4">
    <div 
      :class="circleClass"
      :style="backgroundStyle"
    >
    <span class="text-white">{{ text }}</span>
      <!-- <span :class="textClass">{{ text }}</span> -->
    </div>
  </div>
</template>

<script setup>
import { computed } from 'vue'

const props = defineProps({
  imageUrl: {
    type: String,
    default: ''
  },
  text: {
    type: String,
    default: 'Circle'
  },
  color: {
    type: String,
    default: 'blue'
  },
  size: {
    type: String,
    default: 'text-base'
  }
})
// Computed para el estilo de fondo
const backgroundStyle = computed(() => {
  return props.imageUrl
    ? { backgroundImage: `url(${props.imageUrl})`, backgroundSize: 'cover', backgroundPosition: 'center' }
    : {}
})
// Computed para las clases del círculo
const circleClass = computed(() => {
  return [
      'w-16', 'h-16', 'rounded-full', 'flex', 'items-center', 'justify-center',
    'border-black','border-2',
    props.imageUrl, 
  ]
})
//Computed para el texto
const textClass = computed(() => {
  return [
   `text-${props.color}`,
    props.size
  ]
})
</script>

