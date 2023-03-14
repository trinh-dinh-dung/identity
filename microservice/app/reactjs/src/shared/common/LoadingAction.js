export async function openLoading() {
    if (document.getElementById("loading-main")) {
        document.getElementById("loading-main").style.display = "flex";
    }
}

export async function closeLoading() {
    if (document.getElementById("loading-main")) {
        document.getElementById("loading-main").style.display = "none";
    }
}
