<template>
  <div class="container-fluid">
    <div class="row my-5">
      <div class="col-12 d-flex justify-content-center">
        <!-- about me card -->
        <div class="card about-card text-center bg-turq-dark text-light">
          <div class="">
            <div class="my-3">
            <h1>About Me</h1>
            <img src="src/assets/img/IMG_9655.jpg" alt="Picture of me" width="260" class="img-fluid rounded-pill">
            </div>
            <div class="text-start mx-3">
              <ul>
                <li class="fs-4 my-2"><b>What is my name? Nicholas Sondrup</b></li>
                <li class="fs-5 my-2"><b>What is my quest?</b> To make fantastic applications from well structured and secure back ends to alluring and accessible front ends.</li>
                <li class="my-2"><b>What is my favorite color?</b> Turquoise.</li>
                <li class="my-2"><b>What is the airspeed velocity of an unladen swallow?</b> Assuming a european swallow, about 24 miles per hour or 11 meters a second.</li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'AboutPage'
}
</script>

<style lang="scss" scoped>
.about-card{
  max-width: 30rem;
}

</style>