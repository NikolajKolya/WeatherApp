<script setup>

import {onMounted, ref} from "vue";
import LoadingComponent from "@/components/LoadingComponent.vue";
import WeatherCalendarItem from "@/components/WeatherCalendarItem.vue";
import WeatherOnDayComponent from "@/components/WeatherOnDayComponent.vue";

  const apiBaseUrl = process.env.VUE_APP_API_URL

  const isLoading = ref(true)

  const calendarData = ref(null)

  const isClicked = ref(false)

  const dateForWeather = ref(null)

  onMounted(async () =>
  {
    await LoadCalendar();
  })

  async function LoadCalendar()
  {
    calendarData.value = (await (await fetch(apiBaseUrl + '/api/Weather/GetCalendar')).json())
    isLoading.value = false
  }


  function LoadWeatherDataForOneDay(date)
  {
    isClicked.value = true
    dateForWeather.value = date
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
          @click="LoadWeatherDataForOneDay(item.date)"
      />
    </div>
  </div>
  <WeatherOnDayComponent v-if="isClicked" :date=dateForWeather />
</template>
