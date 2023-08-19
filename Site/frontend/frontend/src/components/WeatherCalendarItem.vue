<script setup>
import {defineProps, onMounted, ref} from "vue";

  const props = defineProps({
    shortWeather: Object
  })

  const weatherImage = ref(null)

  onMounted(async () =>
  {
    await OnLoad();
  })

  async function OnLoad()
  {
    if (props.shortWeather.shortWeather.temperature > 23)
    {
      weatherImage.value = "images/sun.png"
    }
    else if (props.shortWeather.shortWeather.temperature < 23 && props.shortWeather.shortWeather.temperature > 4)
    {
      weatherImage.value = "images/cloud.png"
    }
    else if (props.shortWeather.shortWeather.temperature <= 4)
    {
      weatherImage.value = "images/snowflake.png"
    }
  }

</script>

<template>
  <div>
    <div class="weather-calendar-item-container weather-calendar-item-top">
      <div>
        {{ props.shortWeather.date }}
      </div>

      <div>
        <img class="weather-calendar-item-picture" :src="weatherImage">
      </div>
    </div>

    <div class="weather-calendar-item-container weather-calendar-item-bottom">
      {{ props.shortWeather.shortWeather.temperature }}°C
    </div>
  </div>
</template>
