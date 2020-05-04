let sidebar = document.getElementById('sidebar');
sidebar.addEventListener('mouseenter', function () { this.classList.remove("active"); });
sidebar.addEventListener('mouseleave', function () { this.classList.add("active"); });