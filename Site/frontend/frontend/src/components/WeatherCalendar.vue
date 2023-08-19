<script setup>
  import {onMounted, ref, defineEmits } from "vue";
  import LoadingComponent from "@/components/LoadingComponent.vue";
  import WeatherCalendarItem from "@/components/WeatherCalendarItem.vue";

  const emit = defineEmits(['displayWeatherForDate'])

  const apiBaseUrl = process.env.VUE_APP_API_URL

  const isLoading = ref(true)

  const calendarData = ref(null)

  onMounted(async () =>
  {
    await LoadCalendar();
  })

  async function LoadCalendar()
  {
    calendarData.value = (await (await fetch(apiBaseUrl + '/api/Weather/GetCalendar')).json())
    isLoading.value = false
  }

  async function LoadWeatherDataForOneDay(date)
  {
    emit('displayWeatherForDate', date)
  }

</script>

<template>
  <LoadingComponent v-if="isLoading" />

  <div v-if="!isLoading">
    <div class="weather-calendar-container">

      <WeatherCalendarItem
          v-for="item in calendarData.calendarItems"
          :key="item.date"
          :shortWeather="item"
          @click="async () => await LoadWeatherDataForOneDay(item.date)"
      />

    </div>
  </div>
</template>
