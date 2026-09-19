document.addEventListener("DOMContentLoaded", function () {

    const card = document.getElementById("card");

    const form = document.getElementById("loginForm");

    const eye = document.getElementById("eye");

    const eyeIcon = document.getElementById("eyeIcon");

    const password = document.getElementById("password");

    const email = document.getElementById("email");

    const btn = document.getElementById("btn");

    const btnState = document.getElementById("btnState");


    /* =========================================
       SHOW / HIDE PASSWORD
    ========================================= */

    if (eye && password && eyeIcon) {

        eye.addEventListener("click", function () {

            if (password.type === "password") {

                password.type = "text";

                eyeIcon.innerHTML = `
                    <path d="M17.94 17.94A10.07 10.07 0 0 1 12 20
                    c-7 0-11-8-11-8
                    a18.45 18.45 0 0 1 5.06-5.94
                    M9.9 4.24A9.12 9.12 0 0 1 12 4
                    c7 0 11 8 11 8
                    a18.5 18.5 0 0 1-2.16 3.19
                    m-6.72-1.07a3 3 0 1 1-4.24-4.24"/>
                    <line x1="1" y1="1" x2="23" y2="23"/>
                `;

            }
            else {

                password.type = "password";

                eyeIcon.innerHTML = `
                    <path d="M1 12s4-8 11-8
                    11 8 11 8
                    -4 8-11 8
                    -11-8-11-8z"/>

                    <circle cx="12"
                            cy="12"
                            r="3"/>
                `;
            }

        });

    }


    /* =========================================
       FORM SUBMIT
    ========================================= */

    if (form) {

        form.addEventListener("submit", function (e) {

            /*
             * IMPORTANT:
             *
             * Do NOT use:
             *
             * e.preventDefault();
             *
             * because ASP.NET MVC needs to receive
             * the form request.
             */


            const emailValue =
                email.value.trim();

            const passwordValue =
                password.value.trim();


            /* Basic validation */

            if (!emailValue || !passwordValue) {

                e.preventDefault();

                btnState.innerHTML =
                    "Please enter Email and Password";

                btn.disabled = false;

                return;
            }


            /*
             * Allow ASP.NET MVC
             * controller to receive the request.
             */

            btn.disabled = true;

            btnState.innerHTML =
                "Signing in...";

        });

    }


    /* =========================================
       3D CARD EFFECT
    ========================================= */

    if (card &&
        window.matchMedia("(pointer: fine)").matches) {

        document.addEventListener(
            "mousemove",
            function (e) {

                const rect =
                    card.getBoundingClientRect();

                const x =
                    (e.clientX - rect.left)
                    / rect.width - 0.5;

                const y =
                    (e.clientY - rect.top)
                    / rect.height - 0.5;


                const rotateX =
                    -y * 8;

                const rotateY =
                    x * 8;


                card.style.transform =
                    `rotateX(${rotateX}deg)
                     rotateY(${rotateY}deg)`;
            }
        );


        card.addEventListener(
            "mouseleave",
            function () {

                card.style.transform =
                    "rotateX(0deg) rotateY(0deg)";
            }
        );

    }

});