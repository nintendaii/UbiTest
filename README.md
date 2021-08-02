# AppLovin SDK
Setting up SDK:
1. Clone this project and open the project in the Unity Editor.
2. Under `File > Build Settings`, click on the mobile platform of choice and click on `Player Settings`.
3. Update the iOS bundle identifier and/or Android package name with your own unique identifier(s) associated with the application you will create in the MAX dashboard (or already created, if it is an existing app).
4. Paste `android-keys.json` and/or `ios-keys.json` files to the `Assets` folder.
5. Go to `AppLovin > Integration > Mediated Networks`. Import GoogleAdMob package and paste Android/iOS App ID`s.
6. Build your project.

# Facebook SDK
Setting up SDK:
1. Go to `Facebook > Edit Settings` and paste your App ID.
2. Follow [these steps.](https://developers.facebook.com/docs/unity/getting-started/android)
## Important
Currently the screenshot sharing logic is implemented via [NativeShare Pluggin](https://github.com/yasirkula/UnityNativeShare). 
The reason it works this way is because Facebook [depreciated](https://developers.facebook.com/blog/post/2018/07/31/platform-update-publish-permission/?locale=ru_RU) `publish_actions` permission.

![image](https://i.ibb.co/ggCkQWQ/Screenshot-2021-08-02-at-11-35-03.png)

More research is needed to implement the sharing functionality via Facebook SDK. It would be a good solution to create
a plugin or to play around with Facebook API.

# GameAnalytics SDK
Visit https://go.gameanalytics.com/game/156251/live-feed to see all the Design events sended by the app. Invitation sent to the Ubisoft team.

# Diawi

Link https://i.diawi.com/tQjqx4 sent to the Ubisoft team.

# Tests

See the `Test all modes 📝` job in [Actions](https://github.com/nintendaii/UbiTest/actions).
Job`s yaml code:

```yaml
testRunner:
   name: Test all modes 📝
   runs-on: ubuntu-latest
   steps:
     - name: Checkout code
       uses: actions/checkout@v2

     - name: Create LFS file list
       run: git lfs ls-files -l | cut -d' ' -f1 | sort > .lfs-assets-id

     - name: Restore LFS cache
       uses: actions/cache@v2
       id: lfs-cache
       with:
         path: .git/lfs
         key: ${{ runner.os }}-lfs-${{ hashFiles('.lfs-assets-id') }}

     - name: Git LFS Pull
       run: |
         git lfs pull
         git add .
         git reset --hard
     - name: Restore Library cache
       uses: actions/cache@v2
       with:
         path: Library
         key: Library-test-project
         restore-keys: |
           Library-test-project-
           Library-
     - uses: webbertakken/unity-test-runner@v2
       id: testRunner
       with:
         testMode: all

     - uses: actions/upload-artifact@v2
       with:
         name: Test results (all modes)
         path: ${{ steps.testRunner.outputs.artifactsPath }}
```

# CI / CD

See all jobs in [workflow](https://github.com/nintendaii/UbiTest/tree/main/.github/workflows) folder. Go to `Jobs fix` workflow in [Actions](https://github.com/nintendaii/UbiTest/actions)  section and select Android/iOS artifact to download build.
