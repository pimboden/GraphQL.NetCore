<template>
  <div v-if="property">
    <h3>{{ property.name }} {{ property.family }}</h3>
    <p>{{ formatCurrency(property.value) }}</p>
    <p>
      <NuxtLink to="/realestate">
        Properties
      </NuxtLink>
    </p>
  </div>
</template>

<script>
import property from '~/apollo/queries/property'    
export default {
  apollo: {
    property: {
      query: property,
      prefetch: ({ route }) => ({ id: route.params.id }),
      variables() {
        return { id: this.$route.params.id }
      }
    }
  },
  methods: {
    formatCurrency(num) {
      const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2
      })
      return formatter.format(num)
    }
  },
  head() {
    return {
      title: (this.property ? `${this.property.name} ${this.property.family}` : 'Loading')
    }
  }
}
</script>

<style>
img {
  max-width: 600px;
}
</style>