<template>
  <div class="container">
    <div class="row align-items-center">
      <div class="col align-self-center">
        <form class=" border p-5 rounded">
          <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Email address</label>
            <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
          </div>
          <div class="mb-3">
            <label for="exampleInputPassword1" class="form-label">Password</label>
            <input type="password" class="form-control" id="exampleInputPassword1">
          </div>
          <div class="mb-3 form-check">
            <input type="checkbox" class="form-check-input" id="exampleCheck1">
            <label class="form-check-label" for="exampleCheck1">16 év alatti gyerek</label>
          </div>
          <button type="submit" class="btn btn-primary">Foglalas</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "TravelTo"
}
</script>

<style scoped>

</style>