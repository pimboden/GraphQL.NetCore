<template>
  <div>
    <h3>Properties</h3>
    <ul>
      <li v-for="property in properties" :key="property.id">
           <NuxtLink :to="`property/${property.id}`">
          {{ property.name }} {{ property.family }} {{ property.city }}
        </NuxtLink>
      </li>
    </ul>
    <div>{{properties}}</div>
  </div>
</template>
<<script>
import properties from '~/apollo/queries/properties'  
export default {  
  apollo: {
    properties: {
      prefetch: true,
      query: properties
    }
  },
  head: {
    title: 'Properties with Apollo'
  }
}
</script>
<style>
ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
  line-height: 1.6;
}

</style>