<template>
  <div class="flex flex-wrap justify-center items-center space-x-4 space-y-4">
    <button 
      :class="buttonClass"
      :style="backgroundStyle"
    >
     
    </button>
  </div>
</template>

<script setup>
import { computed } from 'vue'

const props = defineProps({
  imageUrl: {
    type: String,
    default: ''
  },
 
  size: {
    type: String,
    default: 'text-base'
  }
})

const backgroundStyle = computed(() => {
    console.log(props.imageUrl)
  return props.imageUrl
    ? { backgroundImage: `url(${props.imageUrl})`, backgroundSize: 'cover', backgroundPosition: 'center' }
    : {  }
})

const buttonClass = computed(() => {


  return [
    'w-20', 'h-20', 'rounded-full', 'flex', 'items-center', 'justify-center',
    'border-black', 'border-2', 'focus:outline-none',"space-x-19",
    props.imageUrl ? '' : "bg-white"
  ]
})

</script>

<style scoped>
button:focus {
  outline: none;
}
</style>
