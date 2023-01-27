<template>
    <div class="container-fluid fixed-bottom">
        <div class="d-flex justify-content-center">
            <h5 class="">Ügyfélszolgálat: </h5>
            <ul>
                <li>Tel.: +36 1 123 1234</li>
                <li>E-mail: rapulosprojekt@ugyfelszolgalat.hu</li>
            </ul>
        </div>

    </div>
</template>

<script>
export default {
  name: "Footer"
}
</script>

<style scoped>
.container-fluid{
    height: auto;
    background: linear-gradient(90deg, rgba(0,207,194,1) 0%, rgba(22,60,135,1) 100%);
}
ul{
    list-style: none;
}
</style>