<script setup>

import {defineProps, onMounted, ref} from "vue";
  const props = defineProps({
    temperature: Number
  })

  const weatherImage = ref(null)

  onMounted( async() => {
    await OnLoad()
  })

  async function OnLoad(){
    if (props.temperature >= 23)
    {
      weatherImage.value = "images/sun.png"
    }
    else if (props.temperature > 4)
    {
      weatherImage.value = "images/cloud.png"
    }
    else if (props.temperature <= 4)
    {
      weatherImage.value = "images/snowflake.png"
    }
  }
</script>

<template>
    <img class="weather-calendar-item-picture" :src="weatherImage">
</template>