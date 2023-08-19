<script setup>

  // API base URL
  import {onMounted, ref} from "vue";
  import DayWeatherComponent from "@/components/DayWeatherComponent.vue";
  import LoadingComponent from "@/components/LoadingComponent.vue";
  import WeatherCalendar from "@/components/WeatherCalendar.vue";

  const apiBaseUrl = process.env.VUE_APP_API_URL

  const isLoading = ref(true)

  const selectedDate = ref(null)

  // OnMounted hook
  onMounted(async () =>
  {
    await OnLoad();
  })

  // Called when page is loaded
  async function OnLoad()
  {
    // Initially selected date = current date
    let currentDate = ((await (await fetch(apiBaseUrl + '/api/Weather/CurrentDate')).json()))
        .currentDate
    await OnCalendarDateChanged(currentDate)

    isLoading.value = false
  }

  // Called, when calendar emits the date
  async function OnCalendarDateChanged(date)
  {
    selectedDate.value = date
  }

</script>

<template>
  <div class="centered">

    <LoadingComponent v-if="isLoading" />

    <div v-if="!isLoading">
      <DayWeatherComponent :key="selectedDate" :date="selectedDate" />
    </div>

    <WeatherCalendar @displayWeatherForDate="async (d) => await OnCalendarDateChanged(d)" />
  </div>
</template>